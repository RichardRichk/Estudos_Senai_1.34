const numeros = [1, 8, 6, 5, 9, 100, 500];

const nMenor10 = numeros.filter((n) => {
    return n <10;
});

console.log(nMenor10);

const comentarios = [
    {comentario : "bla bla", exibe: true},
    {comentario : "merda", exibe: false},
    {comentario : "bla bla", exibe: true}
]

const comentariosOk = comentarios.filter((c)=>{
    return c.exibe == true;
} );

console.log(comentariosOk);