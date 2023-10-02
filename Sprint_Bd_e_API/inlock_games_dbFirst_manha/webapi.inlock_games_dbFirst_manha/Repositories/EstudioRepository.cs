﻿using Microsoft.EntityFrameworkCore;
using webapi.inlock_games_dbFirst_manha.Contexts;
using webapi.inlock_games_dbFirst_manha.Domains;
using webapi.inlock_games_dbFirst_manha.Interfaces;

namespace webapi.inlock_games_dbFirst_manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {

        InlockContext ctx = new InlockContext();



        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);


            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;

                ctx.Estudios.Update(estudioBuscado);

                ctx.SaveChanges();
            }
     
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio estudio)
        {

            //Cria um Id Guid toda vez que um objeto for criado (Porem ja foi implementado na Domain);
            //estudio.IdEstudio = Guid.NewGuid();

            ctx.Estudios.Add(estudio);


            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            ctx.Estudios.Remove(estudioBuscado);

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
