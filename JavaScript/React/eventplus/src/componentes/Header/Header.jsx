import React from 'react';
import './Header.css'

import Container from '../Container/Container';
import Nav from '../Nav/nav';
import PerfilUsuario from '../PerfilUsuario/PerfilUsuario';

import menubar from '../../assets/images/menubar.png';

const Header = () => {
    return (
        <header className='headerpage'>
            <Container>

                <div className="header-flex">

                    <img 
                    src={menubar} 
                    alt="Imagem menu de barras. serve para ativar e exibir ou esconder o menu no smarphone" 
                    />

                    <Nav />
                    <PerfilUsuario />

                </div>

            </Container>
        </header>
    );
};

export default Header;