function doDestacaTexto(termoBusca, Texto) {

    termoBusca = termoBusca.trim();

    // armazena o texto original se ainda não estiver sido.
    var TextoOriginal = Texto;
    if (localStorage.getItem("textoOriginal") === null) {
        localStorage.setItem("textoOriginal", Texto);
    }
    else {
        Texto = localStorage.getItem("textoOriginal");
    }

    if (termoBusca.length > 0) {
        //Estilo que será aplicado
        inicioTag = "<font style='color:#b22222'><b>";
        fimTag = "</b></font>";

        var novoTexto = "";
        var indice = 0;
        var lcTermoBusca = "";
        var lcTexto = "";
        var control = 0;

        //reduz as strings para minuscula apenas para localizar a posição em que ocorre o termo de busca
        lcTermoBusca = termoBusca.toLowerCase();
        lcTexto = Texto.toLowerCase();

        while (Texto.length > termoBusca.length) {
            //verifica a posição onde está o termo de busca no texto
            if (control > 0) {
                lcTexto = Texto.toLowerCase();
                indice = lcTexto.indexOf(lcTermoBusca, indice);
                if (indice == -1) {
                    novoTexto += Texto;
                    break;
                }
            }
                // se não encontrar o termo de busca carrega o texto original
            else {
                indice = lcTexto.indexOf(lcTermoBusca, indice);
                if (indice == -1) {
                    novoTexto += localStorage.getItem("textoOriginal");
                    break;
                }
            }

            //adiciona as tags para destacar a palavra pesquisada.
            novoTexto += Texto.substring(0, indice) + inicioTag + Texto.substr(indice, termoBusca.length) + fimTag;
            Texto = Texto.substr(indice + termoBusca.length);
            indice = 0;
            control++;
        }
        //preenche o elemento HTML com a palavra pesquisada em destaque
        document.getElementById("log_TextoValidacao").innerHTML = novoTexto;
    }
    else {
        alert("Digite algo, por favor!");
    }
}

function mostrarOculto()
{
    document.getElementById("busca").style.visibility = "visible";
    document.getElementById("bt_busca").style.visibility = "visible";
    document.getElementById("bt_busca").currentStyle.visibility = "visible";    
}

function limpar()
{
    document.getElementById("log_TextoValidacao").innerText = "";
}

function getTextoValidacao()
{
    document.getElementById("textoValidacao").innerHTML = localStorage.getItem("textoOriginal");
}

function validacaoPrevia()
{
    var btn_arquivo = document.getElementById("Arquivo").value;
    if (btn_arquivo.length < 1) {
        alert("escolha um arquivo!");
        return;
    }
    document.forms["form1"].submit();
}

//function mostrarBotoes()
//{
//    document.getElementById("gerapdf").style.visibility = 'hidden';
//    alert("esconder botao!");
//}