import React, { Fragment, useState } from 'react';
import './TipoEventosPage.css';
import Title from '../../components/Titulo/Titulo';
import MainContent from '../../components/Main/MainContent.jsx'
import Container from '../../components/Container/Container';
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';

import tipoEventoImage from '../../assets/images/tipo-evento.svg'


const TipoEventosPage = () => {

    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao

    function handleSubmit() {
        alert('Bora Cadastrar')
    }

    function handleUpdate() {
        alert('Bora Editar')
    }

    return (
        <>
            <MainContent>
                <section className="cadastro-evento-section">
                    <Container>
                        <div className="cadastro-evento__box">                       
                            <Title titleText={"Cadastro Tipos de Eventos"}/>

                            <ImageIllustrator 
                                imageRender={tipoEventoImage}
                            />

                            <form 
                                className='ftipo-evento'
                                onSubmit={frmEdit ? handleUpdate : handleSubmit}
                            >
                                
                                {/* Cadastrar ou Editar */}
                                {
                                    !frmEdit ? (<p>Tela de Cadastro</p>) : (<p>Tela de Edicao</p>)
                                }
                            </form>
                        </div>
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default TipoEventosPage;