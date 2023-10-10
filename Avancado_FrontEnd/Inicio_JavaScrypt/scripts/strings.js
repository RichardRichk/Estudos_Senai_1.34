function changeName(){
    event.preventDefault();

    let nome = document.getElementById(`nome`).Value;
    let nick = document.getElementById(`nick`).Value;

    document.getElementById('res-nick').innerHTML = nome.replace(nome, `Ola, ${nick}`);

}