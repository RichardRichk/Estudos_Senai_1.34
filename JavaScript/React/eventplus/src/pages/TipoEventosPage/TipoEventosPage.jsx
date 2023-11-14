import React, { Fragment, useEffect, useState } from 'react';
import './TipoEventosPage.css';
import Title from '../../components/Titulo/Titulo';
import MainContent from '../../components/Main/MainContent.jsx'
import Container from '../../components/Container/Container';
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import TableTp from './TableTp/TableTp.jsx';


import tipoEventoImage from '../../assets/images/tipo-evento.svg'
import { Input, Button } from "../../components/FormComponents/FormComponents.jsx";
import api, {eventsTypeResource} from "../../Services/Service.js"



const TipoEventosPage = () => {

    //state
    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao

    const [titulo, setTitulo] = useState("");

    const [tipoEventos, setTipoEventos] = useState([]);

    useEffect(()=>{
        
        //define a chamada em nossa api
        async function loadEventsType() {
            
            try {
                const retorno = await api.get(eventsTypeResource);
                setTipoEventos(retorno.data);

                console.log(retorno.data);

            } catch (error) {
                console.log("Erro na api");
                console.log(error);
            }
            
        }

        // chama a funcao/api no carregamento da pagina/componente
        loadEventsType();
    }, [])

    async function handleSubmit(e) {
        e.preventDefault(); //Evita o submit do formulario
        if (titulo.trim().length <= 3) {
            alert("O titulo deve ter pelo menos 3 caracteres");
        }

        try {
            const promiseRetorno = await api.post(eventsTypeResource, {
                titulo:titulo
            });
            
            setTitulo("");

            alert("Cadastrado com sucesso");
            console.log(promiseRetorno)

        } catch (error){
            alert("Deu ruim no submit");
        }

    }

    function handleUpdate() {
        alert('Bora Editar')
    }

    //Cancela a tela/acao de edicao (volta para o form de cadastro)
    function editActionAbort() {
        alert(`Cancelae a tela de edicao de dados`)
    }

    //mostra o formulario de inscricao
    function showUpdateForm(){
        alert(`Vamos mostrar o formulario de edicao`)
    }

    //apaga o tipo de evento na api
    function handDelete(idElement) {
        alert(`Vamos aoagar o evento de id: ${idElement}`);
    }

    return (
        <>
            <MainContent>
                {/* Formulario de cadastro do tipo evento */}
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
                                    !frmEdit ? 
                                    //Cadastrar
                                    <>
                                    (<p>Tela de Cadastro</p>) 
                                    <Input 
                                        id={"Titulo"}
                                        placeholder={"Titulo"}
                                        name={"titulo"}
                                        type={"text"}
                                        required={"required"}
                                        value={titulo}
                                        manipulationFunction={(e) => {
                                            setTitulo(e.target.value);
                                        }}
                                    />
                                        <Button 
                                            textButton="Cadastrar"
                                            id="Cadastrar"
                                            name="cadastrar"
                                            type="submit"
                                        />
                                    </>
                                    : 
                                    //Editar
                                    (<p>Tela de Edicao</p>)
                                }
                            </form>
                        </div>
                    </Container>
                </section>

                {/* Listagem de tipo de eventos */}
                <section className='lista-eventos-section'>
                    <Container>
                        <Title titleText={"lista tipo de eventos"} color="white"/>

                        <TableTp 
                            dados={tipoEventos}
                            fnUpdate={showUpdateForm}
                            fnDelete={handDelete}
                        />
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default TipoEventosPage;