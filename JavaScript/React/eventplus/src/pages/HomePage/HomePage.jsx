import React from 'react';
import './HomePage.css';
import Header from '../../components/Header/Header';
import Title from '../../components/Titulo/Titulo';
import Banner from '../../components/Banner/Banner';
import MainContent from '../../components/Main/MainContent'
import VisionSection from '../../components/VisionSection/VisionSection';
import ContactSection from '../../components/ContactSection/ContactSection';
import Container from '../../components/Container/Container';
import NextEvent from '../../components/NextEvent/NextEvent';


const HomePage = () => {
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
                            <NextEvent 
                                title={"Evento X"}
                                decription={"Evento Legal"}
                                eventDate={"10/11/2024"}
                                idEvent ={"idEvent"}
                            />
                            <NextEvent 
                                title={"Evento X"}
                                decription={"Evento Legal"}
                                eventDate={"10/11/2024"}
                                idEvent ={"idEvent"}
                            />
                            <NextEvent 
                                title={"Evento X"}
                                decription={"Evento Legal"}
                                eventDate={"10/11/2024"}
                                idEvent ={"idEvent"}
                            />
                            <NextEvent 
                                title={"Evento X"}
                                decription={"Evento Legal"}
                                eventDate={"10/11/2024"}
                                idEvent ={"idEvent"}
                            />
                            <NextEvent 
                                title={"Evento X"}
                                decription={"Evento Legal"}
                                eventDate={"10/11/2024"}
                                idEvent ={"idEvent"}
                            />
                            <NextEvent 
                                title={"Evento X"}
                                decription={"Evento Legal"}
                                eventDate={"10/11/2024"}
                                idEvent ={"idEvent"}
                            />
                            <NextEvent 
                                title={"Evento X"}
                                decription={"Evento Legal"}
                                eventDate={"10/11/2024"}
                                idEvent ={"idEvent"}
                            />
                            <NextEvent 
                                title={"Evento X"}
                                decription={"Evento Legal"}
                                eventDate={"10/11/2024"}
                                idEvent ={"idEvent"}
                            />
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