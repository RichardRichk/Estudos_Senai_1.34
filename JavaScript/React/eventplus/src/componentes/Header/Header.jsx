import React, {useState} from 'react';
import './Header.css'

import Container from '../Container/Container';
import Nav from '../Nav/Nav.jsx';
import PerfilUsuario from '../PerfilUsuario/PerfilUsuario';

import menubar from '../../assets/images/menubar.png';

const Header = () => {

    const [exibeNavbar, setExibeNavbar] = useState(false); //Exibe/Esconde menu

    return (
        <header className='headerpage'>
            <Container>

                <div className="header-flex">

                    <img 
                    src={menubar} 
                    alt="Imagem menu de barras. serve para ativar e exibir ou esconder o menu no smarphone" 
                    onClick={()=>{setExibeNavbar(true)}}
                    className="headerpage__menubar"
                    />

                    <Nav exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} />
                    <PerfilUsuario />

                </div>

            </Container>
        </header>
    );
};

export default Header;