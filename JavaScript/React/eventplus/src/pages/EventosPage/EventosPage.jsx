import React from 'react';
import Title from '../../components/Titulo/Titulo';
import './EventosPage.css';
import MainContent from '../../components/Main/MainContent';
import Container from '../../components/Container/Container';
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';

import EventoImage from '../../assets/images/evento.svg'

const EventosPage = () => {
    return (
        <>
            <MainContent>
                <Container>
                    <div className='cadastro-evento__box'>
                        <Title titleText={"Cadastro de Eventos"}/>

                        <ImageIllustrator
                            imageRender={EventoImage}
                        />
                    </div>

                </Container>
            </MainContent>
        </>
    );
};

export default EventosPage;