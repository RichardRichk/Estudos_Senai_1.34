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
import Notification from '../../components/Notification/Notification';



const TipoEventosPage = () => {

    //state

    const [notifyUser, setNotifyerUser] = useState();

    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao

    const [titulo, setTitulo] = useState("");

    const [tipoEventos, setTipoEventos] = useState([]); //array


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

            const buscaEventos = await api.get(eventsTypeResource);

                setTipoEventos(buscaEventos.data); //atualiza a variavel e roda o useState novamente(que da um get na api)

            setNotifyerUser({
                titleNote: "Sucesso",
                textNote: `${titulo} cadastrado com sucesso`,
                imgIcon: "Sucess",
                imgAlt: "Imagem de ilustracai de sucessi.moca segurando um balao com simbolo de confirmacao ok",
                showMessage: true
            });
            console.log(promiseRetorno)

        } catch (error){
            alert("Deu ruim no submit");
        }

    }

    //Cadastra a atualizacao na api
    function handleUpdate(e) {
        e.preventDefault();
        
    }

    //Cancela a tela/acao de edicao (volta para o form de cadastro) {ESTA SENDO USADA NO PROPRIO COMPONENTE DO BOTAO}
    function editActionAbort() {
        setFrmEdit(false);
        setTitulo("");
    }

    //mostra o formulario de inscricao
    async function showUpdateForm(idElement){
        setFrmEdit(true);
        try {
            const retorno = await api.get(`${eventsTypeResource}/${idElement}`);
            setTitulo(retorno.data.titulo);
        } catch (error) {
            
        }
    }

    //apaga o tipo de evento na api
    async function handDelete(idElement, tituloElement) {
        
        //Se nao confirma a exclusao, cancela a acao
        if (window.confirm(`Deseja apagar ${tituloElement} ?`)) {
            
            try {
                const promiseRetorno = await api.delete(`${eventsTypeResource}/${idElement}`);
                if (promiseRetorno.status == 204) {

                    const buscaEventos = await api.get(eventsTypeResource);

                    setTipoEventos(buscaEventos.data); //atualiza a variavel e roda o useState novamente(que da um get na api)

                    setNotifyerUser({
                        titleNote: "Sucesso",
                        textNote: `${tituloElement} excluido com sucesso`,
                        imgIcon: "Sucess",
                        imgAlt: "Imagem de ilustracai de sucessi.moca segurando um balao com simbolo de confirmacao ok",
                        showMessage: true
                    });
                }
    
            } catch (error){
                alert("Deu ruim no excluir");
            }

        }
        
    }


    return (
        <>

        <Notification {...notifyUser} setNotifyUser={setNotifyerUser} />
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
                                    <>
                                        (<p>Tela de Edicao</p>)

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

                                    <div className='buttons-editbox'>
                                        <Button 
                                            textButton="Atualizar"
                                            id="Atualizar"
                                            name="Atualizar"
                                            type="submit"
                                            manipulationFunction={handleUpdate}
                                            additionalClass = "button-component--midle"
                                        />
                                        <Button 
                                            textButton="Cancelar"
                                            id="Cancelar"
                                            name="Cancelar"
                                            type="button"
                                            manipulationFunction={editActionAbort}
                                            additionalClass = "button-component--midle"
                                        />
                                    </div>
                                    </>
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