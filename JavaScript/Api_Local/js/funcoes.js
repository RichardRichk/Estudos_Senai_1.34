const urlViaCep = `https://viacep.com.br/ws`;
const urlViaCepProfessor = `http://172.16.35.155:3000/myceps`;
const urlViaContatoProfessor = `http://172.16.35.155:3000/Contato`;

function cadastrar(e) {
    e.preventDefault();
    
    const nome = document.getElementById(`nome`).value.Trim();
    const email = document.getElementById(`email`).value.Trim();
    const cep = document.getElementById(`cep`).value.Trim();
    const endereco = document.getElementById(`endereco`).value.Trim();
    const cidade = document.getElementById(`cidade`).value.Trim();
    const estado = document.getElementById(`estado`).value.Trim();
    const numero = document.getElementById(`numero`).value.Trim();

    // if (validaForm(nome, endereco, cep)) {
    //     alert(`Preencha todos os campos`)
    //     return;
    // }

    objCadastro = {
        nome,
        email,
        cep,
        endereco,
        cidade,
        estado,
        numero
    }

    try {
        const primise = await fetch(urlViaContatoProfessor,{data: JSON.stringify(objCadastro), method: "post", headers: {"Content-type" : "application/json"}});
        const dados = await promise.json()
    } catch (error) {
        
    }
}

// function validaForm(nome, endereco, cep) {
//     if (
//         nome.lenght == 0 || nome === undefined ||
//         endereco.lenght == 0 || endereco === undefined ||
//         cep.lenght < 8 || cep === undefined
//     ) {
//         return false;
//     }
// }


async function buscarEndereco(cep){
    // const resources = `/${cep}/json/`

    try{
        // const promise = await fetch(urlViaCep + resources);
        const promise = await fetch(`${urlViaCepProfessor}/${cep}`);

        const endereco = await promise.json();

        console.log(endereco)


        document.getElementById(`endereco`).value = endereco.logradouro;
        document.getElementById(`cidade`).value = endereco.localidade;
        document.getElementById(`estado`).value = endereco.uf;
        document.getElementById(`numero`).value = endereco.numero;
    }   catch (error) {
        alert(`CEP nao existe. Erro: ${error}`)
    }

}

