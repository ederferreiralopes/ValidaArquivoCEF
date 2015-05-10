using System;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibraryValidaArquivoCEF
{
    class Auxiliar
    {
        string textoValidacao = string.Empty;

        public string TextoValidacao
        {
            get { return textoValidacao; }
            set { textoValidacao = value; }
        }

        public void validaEstado(int numLinha, string siglaEstado)
        {
            if (!Properties.Settings.Default.siglaEstados.Contains(siglaEstado))
            {
                textoValidacao += ("Linha: " + numLinha + " Erro no campo: cod do Estado = " + siglaEstado + " : preencher com a sigla do Estado\n");
            }
        }

        private string RemoverAcentos(string strTexto)
        {
            strTexto = strTexto.ToString();
            strTexto = Regex.Replace(strTexto, "[ÁÀÂÃ]", "A");
            strTexto = Regex.Replace(strTexto, "[ÉÈÊ]", "E");
            strTexto = Regex.Replace(strTexto, "[Í]", "I");
            strTexto = Regex.Replace(strTexto, "[ÓÒÔÕ]", "O");
            strTexto = Regex.Replace(strTexto, "[ÚÙÛÜ]", "U");
            strTexto = Regex.Replace(strTexto, "[Ç]", "C");
            strTexto = Regex.Replace(strTexto, "[áàâã]", "a");
            strTexto = Regex.Replace(strTexto, "[éèê]", "e");
            strTexto = Regex.Replace(strTexto, "[í]", "i");
            strTexto = Regex.Replace(strTexto, "[óòôõ]", "o");
            strTexto = Regex.Replace(strTexto, "[úùûü]", "u");
            strTexto = Regex.Replace(strTexto, "[ç]", "c");
            return strTexto;
        }

        public void apagaCaracterEspecial(int numLinha, string linhaAux)
        {
            string texto2 = linhaAux.Replace("[^aA-zZ-Z1-9 ]", "\n"); // regex: /[^0-9A-Za-z]*/ 

            if (linhaAux.Length != texto2.Length)
            {
                textoValidacao += ("Linha: " + numLinha + " Erro no campo: mensagem de aviso 1 = " + linhaAux + " : possui caracter especial!\n");
            }
        }

        public void validaNumeroLotes(int numLinha, string linha, int numLote)
        {
            try
            {
                if (int.Parse(linha.Substring(3, 4)) != numLote)
                {
                    textoValidacao += ("Linha: " + numLinha + " Erro no campo: Lote do servico = " + linha.Substring(3, 4) + " : deveria ser " + numLote + "\n");
                }

            }
            catch (Exception erro)
            {
                textoValidacao += ("Linha: " + numLinha + " Erro no campo: Lote do servico = " + linha.Substring(3, 4) + " : deveria ser " + numLote + "\n");
            }
        }

        public string converteEmMoeda(int numLinha, string linha, string valor)
        {
            try
            {
                valor = valor.Insert(valor.Length - 2, ",");
                Double valorLanc = Double.Parse(valor);
                valor = valorLanc.ToString("c");
            }
            catch (Exception erro)
            {
                textoValidacao += ("Linha: " + numLinha + " Erro no campo: Valor do lancamento = " + linha.Substring(119, 15) + "\n");
            }

            return valor;
        }

        public void validaNsr(int numLinha, string linha, int numNsr)
        {
            try
            {
                if (int.Parse(linha.Substring(8, 5)) != numNsr)
                {
                    textoValidacao += ("Linha: " + numLinha + " Erro no campo: Num. sequencial do Registro = " + linha.Substring(8, 5) + " : deveria ser " + numNsr + "\n");
                }
            }
            catch (Exception erro)
            {
                textoValidacao += ("Linha: " + numLinha + " Erro no campo: Num. sequencial do Registro = " + linha.Substring(8, 5) + " : deveria ser " + numNsr + "\n");
            }
        }

        public void validaCodBanco(int numLinha, string codigo)
        {
            if (!Properties.Settings.Default.codigoBancos.Contains(codigo))
            {
                textoValidacao += ("Linha: " + numLinha + " Erro no campo: banco de destino = " + codigo + " : preencher com o código do banco de destino do bloqueto, conforme constante da 1a a 3a posições na barra da cobrança\n");
            }
        }

        public string TrataOcorencias(string ocorrencias)
        {
            //TABELA G059 - Código das Ocorrências para Retorno. Pode-se informar até 5 ocorrências simultaneamente, cada uma delas codificada com dois dígitos
            string ocorrencias1 = ocorrencias.Substring(0, 2);
            string ocorrencias2 = ocorrencias.Substring(2, 2);
            string ocorrencias3 = ocorrencias.Substring(4, 2);
            string ocorrencias4 = ocorrencias.Substring(6, 2);
            string ocorrencias5 = ocorrencias.Substring(8, 2);

            string[] ocor = new string[5] { ocorrencias1, ocorrencias2, ocorrencias3, ocorrencias4, ocorrencias5 };

            if (ocorrencias.Length >= 2)
            {
                ocorrencias = string.Empty;

                foreach (var item in ocor)
                {
                    switch (item)
                    {
                        case "00": ocorrencias += " Crédito ou Débito Efetivado -> Este código indica que o pagamento foi confirmado\n";
                            break;
                        case "01": ocorrencias += " Insuficiência de Fundos - Débito não efetuado\n";
                            break;
                        case "02": ocorrencias += " Crédito ou Débito Cancelado pelo Pagador/Credor\n";
                            break;
                        case "03": ocorrencias += " Débito Autorizado pela Agência - Efetuado\n";
                            break;
                        case "HA": ocorrencias += " Lote não aceito\n";
                            break;
                        case "HB": ocorrencias += " Inscrição da Empresa Inválida para o Contrato\n";
                            break;
                        case "HC": ocorrencias += " Convênio com a Empresa Inexistente/Inválido para o Contrato\n";
                            break;
                        case "HD": ocorrencias += " Agência/Conta Corrente da Empresa Inexistente/Inválido para o Contrato\n";
                            break;
                        case "HE": ocorrencias += " Tipo de Serviço Inválido para o Contrato\n";
                            break;
                        case "HF": ocorrencias += " Conta Corrente da Empresa com Saldo Insuficiente\n";
                            break;
                        case "HG": ocorrencias += " Lote de Serviço fora de Seqüência\n";
                            break;
                        case "HH": ocorrencias += " Lote de serviço inválido\n";
                            break;
                        case "HI": ocorrencias += " Número da remessa inválido\n";
                            break;
                        case "HJ": ocorrencias += " Arquivo sem HEADER\n";
                            break;
                        case "HM": ocorrencias += " Versão do arquivo inválido\n";
                            break;
                        case "AA": ocorrencias += " Controle inválido\n";
                            break;
                        case "AB": ocorrencias += " Tipo de operação inválido\n";
                            break;
                        case "AC": ocorrencias += " Tipo de serviço inválido\n";
                            break;
                        case "AD": ocorrencias += " Forma de Lançamento inválida\n";
                            break;
                        case "AE": ocorrencias += " Tipo/Número de inscrição inválido\n";
                            break;
                        case "AF": ocorrencias += " Código de convênio inválido\n";
                            break;
                        case "AG": ocorrencias += " Agência/Conta corrente/DV inválido\n";
                            break;
                        case "AH": ocorrencias += " Número seqüencial do registro no lote inválido\n";
                            break;
                        case "AI": ocorrencias += " Código de segmento de detalhe inválido\n";
                            break;
                        case "AJ": ocorrencias += " Tipo de movimento inválido\n";
                            break;
                        case "AK": ocorrencias += " Código da câmara de compensação do banco favorecido/depositário inválido\n";
                            break;
                        case "AL": ocorrencias += " Código do banco favorecido ou depositário inválido\n";
                            break;
                        case "AM": ocorrencias += " Agência mantenedora da conta corrente do favorecido inválida\n";
                            break;
                        case "AN": ocorrencias += " Conta Corrente / DV do favorecido inválido\n";
                            break;
                        case "AO": ocorrencias += " Nome do favorecido não informado\n";
                            break;
                        case "AP": ocorrencias += " Data de lançamento inválido\n";
                            break;
                        case "AQ": ocorrencias += " Tipo/quantidade de moeda inválida\n";
                            break;
                        case "AR": ocorrencias += " Valor do lançamento inválido\n";
                            break;
                        case "AS": ocorrencias += " Aviso ao favorecido - identificação inválida\n";
                            break;
                        case "AT": ocorrencias += " Tipo/número de inscrição do favorecido inválido\n";
                            break;
                        case "AU": ocorrencias += " Logradouro do favorecido não informado\n";
                            break;
                        case "AV": ocorrencias += " Número do local do favorecido não informado\n";
                            break;
                        case "AW": ocorrencias += " Cidade do favorecido não informada\n";
                            break;
                        case "AX": ocorrencias += " CEP/complemento do favorecido inválido\n";
                            break;
                        case "AY": ocorrencias += " Sigla do Estado do Favorecido Inválido\n";
                            break;
                        case "AZ": ocorrencias += " Código/nome do banco depositário inválido\n";
                            break;
                        case "BA": ocorrencias += " Código/nome da agência depositária não informado\n";
                            break;
                        case "BB": ocorrencias += " Seu número inválido\n";
                            break;
                        case "BC": ocorrencias += " Nosso número inválido\n";
                            break;
                        case "BD": ocorrencias += " Inclusão efetuada com sucesso\n";
                            break;
                        case "BE": ocorrencias += " Alteração efetuada com sucesso\n";
                            break;
                        case "BF": ocorrencias += " Exclusão efetuada com sucesso\n";
                            break;
                        case "BG": ocorrencias += " Agência/conta impedida legalmente\n";
                            break;
                        case "CA": ocorrencias += " Código de barras - código do banco inválido\n";
                            break;
                        case "CB": ocorrencias += " Código de barras - código da moeda inválida\n";
                            break;
                        case "CC": ocorrencias += " Código de barras - dígito verificador geral inválido\n";
                            break;
                        case "CD": ocorrencias += " Código de barras - valor do título inválido\n";
                            break;
                        case "CE": ocorrencias += " Código de barras - campo livre inválido\n";
                            break;
                        case "CF": ocorrencias += " Valor do documento inválido\n";
                            break;
                        case "CG": ocorrencias += " Valor do abatimento inválido\n";
                            break;
                        case "CH": ocorrencias += " Valor do desconto inválido\n";
                            break;
                        case "CI": ocorrencias += " Valor de mora inválido\n";
                            break;
                        case "CJ": ocorrencias += " Valor da multa inválido\n";
                            break;
                        case "CK": ocorrencias += " Valor do IR inválido\n";
                            break;
                        case "CL": ocorrencias += " Valor do ISS inválido\n";
                            break;
                        case "CM": ocorrencias += " Valor do IOF inválido\n";
                            break;
                        case "CN": ocorrencias += " Valor de outras deduções inválido\n";
                            break;
                        case "CO": ocorrencias += " Valor de outros acréscimos inválido\n";
                            break;
                        case "CP": ocorrencias += " Valor do INSS inválido\n";
                            break;
                        case "CQ": ocorrencias += " Código de barras inválido\n";
                            break;
                        case "TA": ocorrencias += " Lote não aceito - totais de lote com diferença\n";
                            break;
                        case "TB": ocorrencias += " Lote sem trailler\n";
                            break;
                        case "TC": ocorrencias += " Lote de Arquivo sem trailler\n";
                            break;
                        case "YA": ocorrencias += " Título não encontrado\n";
                            break;
                        case "YB": ocorrencias += " Identificador registro opcional inválido\n";
                            break;
                        case "YC": ocorrencias += " Código padrão inválido\n";
                            break;
                        case "YD": ocorrencias += " Código de ocorrência inválido\n";
                            break;
                        case "YE": ocorrencias += " Complemento de ocorrência inválido\n";
                            break;
                        case "YF": ocorrencias += " Alegação já informada\n";
                            break;
                        case "ZA": ocorrencias += " Agência/conta do favorecido substituída\n";
                            break;
                        default: ocorrencias += "";
                            break;
                    }
                }
            }
            else
            {
                ocorrencias = "Ocorrencia não informada pelo banco\n";
            }
            return ocorrencias;
        }

        public string SegmentoEmpresa(string codSegmento)
        {
            switch (codSegmento)
            {
                case "1": codSegmento = "1 - Prefeituras";
                    break;
                case "2": codSegmento = "2 - Saneamento";
                    break;
                case "3": codSegmento = "3 - Energia";
                    break;
                case "4": codSegmento = "4 - Telefone";
                    break;
                case "5": codSegmento = "5 - Órgãos Governamentais";
                    break;
                case "6": codSegmento = "6 - Carnês e assemelhados";
                    break;
                case "7": codSegmento = "7 - Multas de Trânsito";
                    break;
                case "9": codSegmento = "9 - Exclusivo CAIXA";
                    break;
                default: codSegmento += "cod. segmento não encontrado: " + codSegmento;
                    break;
            }
            return codSegmento;
        }

    }
}
