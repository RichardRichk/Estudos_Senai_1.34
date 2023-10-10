function calcular(){//soma
    event.preventDefault();//parar o submit do formulario

    let n1 = parseFloat(document.getElementById(`n1`).value);
    let n2 = parseFloat(document.getElementById(`n2`).value);
    let op = document.getElementById('operacao').value;
    let resultado;

    if (isNaN(n1) && isNaN(n2)) {
        return alert (`Necessario digitar todos os valores`)
    }
    switch (op) {
        case '+':
            resultado = somar(n1,n2)
            break;
        case '-':
            resultado = subtrair(n1,n2)
            break;
        case '/':
            if (n2 == 0) {
                return alert(`Nao existe divisao por zero ou nulo`); 
            }
            resultado = divisao(n1,n2)
            break;
        case '*':
            resultado = multiplicacao(n1,n2)
            break;
    
        default:
            alert(`A operacao nao foi selecionada!`)
            break;
    }        

        //inserir o resultado no html(DOM
        document.getElementById('result').innerText = `resultado = ${resultado}`;
}

function subtrair(n1, n2) {
    
    return n1 - n2;
    
}

function somar(n1, n2){
    return n1 + n2;
}

function multiplicacao(n1, n2){
    return n1 * n2;
}

function divisao(n1, n2){
    return n1 / n2;
}