const nome = ["Eduardo","Ana Clara","Rodrygo", "Jude", "Cristiano"];
const sobrenome = ["Alves", "Costa", "Costa", "Bellingham", "Ronaldo"];


const nomesCompletos = nome.map((nome, index) =>
 {
    return `${nome} ${sobrenome[index]}`
 });

 nomesCompletos.forEach((nc) => {
    console.log(nc);
 });
