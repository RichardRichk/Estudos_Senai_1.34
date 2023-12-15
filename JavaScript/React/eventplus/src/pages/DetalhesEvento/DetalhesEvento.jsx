    import React, { Fragment, useEffect, useState, useContext } from 'react';
    import "./DetalhesEvento.css"

    import Title from '../../components/Titulo/Titulo';
    import MainContent from '../../components/Main/MainContent.jsx'
    import Container from '../../components/Container/Container';

    import TableDe from './TableDe/TableDe';
    import { useParams } from 'react-router-dom';
    import { UserContext } from '../../context/AuthContext';

    import api, {eventsResource, commentsResource, commentsTrueResource} from "../../Services/Service"

    const DetalhesEvento = () => {

        const { userData } = useContext(UserContext);

        const {idEvento} = useParams();

        const [evento, setEvento] = useState([]);

        const [comentarios, setComentarios] = useState([]);

        async function loadEvent(){
            try {
                const promise = await api.get(`${eventsResource}/${idEvento}`);
                setEvento(promise.data);

            } catch (error) {
                console.log("Erro na api");
                console.log(error);
            }
        }

        async function loadAllComentary() {
            try {
                const promise = await api.get(`${commentsResource}`)

                setComentarios(promise.data);
                console.log("aaaaaaaaaaaaaaaaaaaaaaaaaaa777");
                console.log(promise.data);
            } catch (error) {
                console.log("Erro na api");
                console.log(error);
            }
        }

        async function loadTrueComentary() {
            try {
                const promise = await api.get(`${commentsTrueResource}`)

                setComentarios(promise.data);
                console.log("aaaaaaaaaaaaaaaaaaaaaaaaaaa");
                console.log(promise.data);
            } catch (error) {
                console.log("Erro na api");
                console.log(error);
            }
        }

        function loadComentaryByUser() {
            return (
                <>
                    {userData.nome && userData.role === "Administrador" ? (
                        loadAllComentary()
                    ) : userData.nome && userData.role === "Comum" ? (
                        loadTrueComentary()
                    ) : null}
                </>
            );
        }
        


        useEffect(()=>{
            loadEvent();
            
            loadComentaryByUser();
        }, []);

        return (
            <>
            <MainContent>
                <section className="detalhes-evento-section">
                        <Container>

                            <div className="detalhes-evento__box">     

                                <Title titleText={evento.nomeEvento}/>
                                <>
                                <h1>Descricao</h1>
                                <p>{evento.descricao}</p>
                                
                                <h1>dataEvento</h1>
                                <p>{new Date(evento.dataEvento).toLocaleDateString()}</p>
                                
                                <h1>TipoEvento</h1>
                                
                                <p>Undefined</p>
                                
                                <h1>Instituicao</h1>
                                <p>Undefined</p>
                                </>

                            </div>
                        </Container>
                </section>

                {/* Listagem de comentarios */}
                <section className='lista-comentarios-section'>
                        <Container>
                            <Title titleText={"Comentarios"} color="white"/>

                            <TableDe
                                dadosComent={comentarios}
                            />
                        </Container>
                </section>
            </MainContent>
            </>
        );
    };

    export default DetalhesEvento;
