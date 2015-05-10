using System;
using System.Collections.Generic;

using System.Text;

namespace ClassLibraryValidaArquivoCEF
{
    class Registro5
    {
        string textoValidacao;

        public string TextoValidacao
        {
            get { return textoValidacao; }
            set { textoValidacao = value; }
        }

        public void valida(string linha, string validacao)
        {
            if (linha.Length != 240)
            {
                validacao +=("Fora do Padrão: quantidade de colunas é difente de 240! esta linha possui: " + linha.Length + " colunas\n");
            }
            else
            {
                try
                {
                    // Descrição do Registro “TRAILLER” de lote - “5”
                    string usoFebraban = linha.Substring(8, 9); //5.04 009 017 X(009) Uso exclusivo FEBRABAN
                    string numAvisoDebito = linha.Substring(59, 6); //5.08 060 065 9(006) Número Aviso de Débito
                    string usoFebraban2 = linha.Substring(65, 165); //5.09 066 230 X(165) Uso exclusivo FEBRABAN
                    string ocorrencias = linha.Substring(230, 10); //5.10 231 240 X(010) Ocorrências

                    if (!usoFebraban.Contains("         "))
                    {
                        validacao +=("Erro no campo: Uso FEBRABAN = " + usoFebraban + " : preencher com espaços!\n");
                    }

                    if (!numAvisoDebito.Contains("000000"))
                    {
                        validacao +=("Erro no campo: Número Aviso de Débito = " + numAvisoDebito + " : preencher com zeros!\n");
                    }

                    if (!usoFebraban2.Contains("                                                                                                                                                                     "))
                    {
                        validacao +=("Erro no campo: Uso FEBRABAN = " + usoFebraban2 + " : preencher com espaços!\n");
                    }

                    if (!ocorrencias.Contains("          "))
                    {
                        validacao +=("Erro no campo: Ocorrências do Retorno = " + ocorrencias + " : preencher com espaços!\n");
                    }
                }
                catch (Exception erro)
                {
                    validacao +=("não consegui ler a linha do registro 5 = " + linha + "\n" + erro);
                }
            }

            textoValidacao = validacao;
        }
    }
}
