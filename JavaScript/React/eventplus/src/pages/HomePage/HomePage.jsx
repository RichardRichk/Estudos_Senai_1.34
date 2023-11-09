import React, { useEffect, useState } from 'react';
import './HomePage.css';
import Header from '../../components/Header/Header';
import Title from '../../components/Titulo/Titulo';
import Banner from '../../components/Banner/Banner';
import MainContent from '../../components/Main/MainContent'
import VisionSection from '../../components/VisionSection/VisionSection';
import ContactSection from '../../components/ContactSection/ContactSection';
import Container from '../../components/Container/Container';
import NextEvent from '../../components/NextEvent/NextEvent';

import axios from 'axios';



const HomePage = () => {

    const [nextEvents, setNextEvents] = useState([]); //dados mocados
    const urlLocal = 'http://localhost:5000/api'

    useEffect(() => {
        async function getNextEvents() {
            try {
                const promise = await axios.get(`${urlLocal}/Evento/ListarProximos`);
                const dados = await promise.data;

                setNextEvents(dados)//Atualiza o state
            } catch (error) {
                alert("oia, deu erro aqui viu")
            }
        }


        getNextEvents();//roda a funcao
    },[]);

    return (
        <div>
            <Header />
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
                                    idEvent ={e.id}
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