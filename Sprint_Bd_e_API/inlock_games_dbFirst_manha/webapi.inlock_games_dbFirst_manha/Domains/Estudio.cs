using System;
using System.Collections.Generic;

namespace webapi.inlock_games_dbFirst_manha.Domains;

public partial class Estudio
{
    public Guid IdEstudio { get; set; } = Guid.NewGuid();
                                        //Cria um Id Guid toda vez que um objeto for criado;

    public string Nome { get; set; } = null!;

    public virtual ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
