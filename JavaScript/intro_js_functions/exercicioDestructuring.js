//var - global scope
//let - local scope variable
//const - local scope non variable value


//Exercicio

const filmes = [
    {
        titulo: `Senai`,
        genero: ["Tristeza", "Sofrimento"],
        descricao: `isso ne`,
        emExibicao: true
    },
    {
        titulo: `Casa`,
        genero: ["Felicidade", "Sono"],
        descricao: `dormi ne`,
        emExibicao: false
    },
];


// filmes.forEach((f) => {
//     const {titulo, genero} = f;

//     console.log(`
    
//         Titulo: ${titulo.toUpperCase()};
//         Genero ${genero.toString()}
    
//     `);
// });

filmes.forEach( ( {titulo, genero}, i ) => {
    
    console.log(`
    
        filme${i+1}: 
        Titulo: ${titulo.toUpperCase()};
        Genero ${genero.toString()}
    
    `);
});