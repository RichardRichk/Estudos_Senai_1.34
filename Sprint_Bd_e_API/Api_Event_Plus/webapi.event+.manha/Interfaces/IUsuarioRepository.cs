﻿using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IUsuarioRepository
    {

        void Cadastrar(Usuario usuario);


        Usuario BuscarPorId(Guid id);


        Usuario BuscarPorCadastro(string email, string senha);

    }
}
