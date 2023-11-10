import React from 'react';
import './TipoEventos.css';
import Header from '../../components/Header/Header';
import Title from '../../components/Titulo/Titulo';
import MainContent from '../../components/Main/MainContent.jsx'
import Container from '../../components/Container/Container';


const TipoEventos = () => {
    return (
        <>
            <MainContent>
                <section className="cadastro-evento-section">
                    <Container>
                        <div className="cadastro-evento-box">                       
                            <Title titleText={"Cadastro Tipos de Eventos"}/>

                            <ImageIlustrator />

                            <form className='ftipo-evento'>
                                <p>Formulario sera criado aqui</p>
                            </form>
                        </div>
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default TipoEventos;