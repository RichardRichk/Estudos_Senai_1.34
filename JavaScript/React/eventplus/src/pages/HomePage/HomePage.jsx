import React, { useEffect, useState } from 'react';
import './HomePage.css';
import Title from '../../components/Titulo/Titulo';
import Banner from '../../components/Banner/Banner';
import MainContent from '../../components/Main/MainContent'
import VisionSection from '../../components/VisionSection/VisionSection';
import ContactSection from '../../components/ContactSection/ContactSection';
import Container from '../../components/Container/Container';
import NextEvent from '../../components/NextEvent/NextEvent';
import Notification from '../../components/Notification/Notification';

import api from '../../Services/Service';

import { nextEventResource } from '../../Services/Service';

const HomePage = () => {

    const [notifyUser, setNotifyerUser] = useState();

    const [nextEvents, setNextEvents] = useState([]); //dados mocados

    useEffect(() => {
        async function getNextEvents() {
            try {
                const promise = await api.get(`${nextEventResource}`);
                const dados = await promise.data;

                setNextEvents(dados)//Atualiza o state
            } catch (error) {
                setNotifyerUser({
                    titleNote: "Erro na API",
                    textNote: `Nao foi possivel carregar os proximos evento... Verifique a sua conexao com a internet`,
                    imgIcon: "warning",
                    imgAlt: "Imagem de ilustracai de erro, Cuidado!",
                    showMessage: true
                });
            }
        }


        getNextEvents();//roda a funcao
    },[]);

    return (
        <div>

            <Notification {...notifyUser} setNotifyUser={setNotifyerUser} />

            {/* <Title titleText={"Home Page"} className="margem_acima" /> */}
            <MainContent>

            <Banner />

            {/* PROXIMOS EVENTOS */}

                <section className='proximos-eventos'>
                    <Container>
                        
                        <Title titleText={"Proximos Eventos"}/>

                        <div className='events-box'>

                            {
                                nextEvents.map((e) => {
                                    return (
                                    <NextEvent 
                                    key={e.idEvento}
                                    title={e.nomeEvento}
                                    decription={e.descricao}
                                    eventDate={e.dataEvento}
                                    idEvent ={e.idEvento}
                                    />
                                    );
                                })
                            }

                        </div>

                    </Container>
                </section>

                <VisionSection />

                <ContactSection />

            </MainContent>

        </div>
    );
};

export default HomePage;