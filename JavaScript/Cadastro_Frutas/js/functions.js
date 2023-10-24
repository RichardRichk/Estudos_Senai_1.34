const arrFrutas = []
function cadastrar(e) {
    e.preventDefault();

    const fruta = document.getElementById('fruta').value;
    fruta.trim();
    fruta.toLowerCase();

    arrFrutas.push(fruta);

    arrFrutas.sort();
    let template = "<ul>";

    arrFrutas.forEach(fruta => {
        template += `<li>${fruta}</li>`;
    });

    template += "</ul>";

    document.getElementById("listaFrutas").innerHTML = template;
}