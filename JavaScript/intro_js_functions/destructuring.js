const camisaLacoste = {
    descricao: "camisa lacoste",
    preco: 589,
    tamanho: "m",
    cor: "amarela",
    presente: true
}


const {descricao, preco, presente} = camisaLacoste;


// const {descricao} = camisaLacoste;
// const {preco} = camisaLacoste;

// const descricao = camisaLacoste.descricao;
// const preco = camisaLacoste.preco;

console.log("Produto:");
console.log();

console.log(`Descricao: ${descricao}`);
console.log(`Preco ${preco}`);
console.log(`

    Descricao: ${descricao};
    Preco: ${preco};
    Presente: ${presente ? "sim" : "nao"}

`);


