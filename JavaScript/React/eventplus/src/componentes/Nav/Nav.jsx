import React from 'react';
import './Nav.css';

import logMobile from '../../assets/images/logo-white.svg'
import logDesktop from '../../assets/images/logo-pink.svg'

import { Link } from 'react-router-dom';

const Nav = ({exibeNavbar, setExibeNavbar}) => {

    console.log(`Exibe o menu ? ${exibeNavbar}`)

    return (
        <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>

            <span 
                className='navbar__close'
                onClick={() => {setExibeNavbar(false)}}>
                X
            </span>

            <Link to="/" className='eventlogo'>
            <img 
                className='eventlogo__logo-image' 
                src={window.innerWidth >= 992 ? logDesktop : logMobile} 
                alt="Event Plus Logo" 
            />
            </Link>

            <div className='navbar__items-box'>
                <Link to="/" className='navbar__item'>Home</Link>
                <Link to="/tiposeventos" className='navbar__item'>Tipos de Evento</Link>
                <Link to="/eventos" className='navbar__item'>Eventos</Link>
                <Link to="/login" className='navbar__item'>Login</Link>
                <Link to="/teste" className='navbar__item'>Testes</Link>
            </div>

        </nav>
    );
};

export default Nav;