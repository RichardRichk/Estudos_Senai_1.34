
    //array vazio
const arrFrutas = [];//array global

function cadastrarfrutas(e) {
    e.preventDefault();


const fruta = document.getElementById('fruta').value;
fruta.trim();
fruta.toLowercase();

arrFrutas.push(fruta);
arrFrutas.sort();//ordena o array

console.log(arrFrutas)

let template = "<ul>";

    //   let textoQualquer = []
arrFrutas.forEach((fruta) => {//preenche ou acumula valores na sttring
    template += `
        
            <li>${p.fruta}</li>`;
  });
  template += "</ul>"

  document.getElementById('listarfrutas').innerHTML = template;
}