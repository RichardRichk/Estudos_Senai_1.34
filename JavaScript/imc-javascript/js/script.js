const arrPessoa = [];

function calcular(e) {
    e.preventDefault();

    let nome = document.getElementById("nome").value.trim();
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);

    if (isNaN(altura) || isNaN(peso) || nome.trim() == 0) {
        alert("E necessario preeencher os dados corretamente");
        return;
    }

    // Calcular o IMC
    const imc = calcularImc(altura, peso);
    const txtSituacao = retornaSituacao(imc);


    //gera o objeto com os dados da pessoa
    const pessoa = {nome, altura, peso, imc, situacao : txtSituacao };

    //adiciona a pessoa na lista
    arrPessoa.push(pessoa)

    //listar pessoas
    listarPessoas();
}

function calcularImc(altura, peso) {
    // return peso/ altura **2
    // return peso/(altura* altura)
    return (peso / Math.pow(altura, 2)).toFixed(2);
}

function retornaSituacao(imc) {
    if (imc < 18.5) {
        return "Magreza Severa";
    }
    else if (imc <= 24.99) {
        return "Peso Normal"
    }
    else if (imc <= 29.99) {
        return "Acima do peso"
    }
    else if (imc <= 34.99) {
        return "Obesidade 1"
    }
    else if (imc <= 39.99) {
        return "Obesidade 2"
    }
    else {
        return "CUIDADOOO!!!!!"
    }
}

function listarPessoas(){
    console.log(arrPessoa);
    let template = "";
    
    arrPessoa.forEach((p) => {
        template += `
        <tr>
        <td>${p.nome}</td>
        <td>${p.altura}</td>
        <td>${p.peso}</td>
        <td>${p.imc}</td>
        <td>${p.situacao}</td>
    </tr>`;
    })

    document.getElementById("cadastro").innerHTML = template;

}