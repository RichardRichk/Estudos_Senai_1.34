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
import Spinner from '../../components/Spinner/Spinner'



const TipoEventosPage = () => {

    //state

    const [notifyUser, setNotifyerUser] = useState();

    const [showSpinner, setShowSpinner] = useState(false); //Spinner Loading

    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao

    const [titulo, setTitulo] = useState("");

    const [idEvento, setIdEvento] = useState(null); //Para editar, por conta do evento!

    const [tipoEventos, setTipoEventos] = useState([]); //array


    useEffect(()=>{
        
        //define a chamada em nossa api
        async function loadEventsType() {
            setShowSpinner(true)
            try {
                const retorno = await api.get(eventsTypeResource);
                setTipoEventos(retorno.data);

                console.log(retorno.data);

            } catch (error) {
                console.log("Erro na api");
                console.log(error);
            }
            
            setShowSpinner(false)
        }

        // chama a funcao/api no carregamento da pagina/componente
        loadEventsType();
    }, [])

    async function updateAPI() {
        const buscaEventos = await api.get(eventsTypeResource);

        setTipoEventos(buscaEventos.data); //atualiza a variavel e roda o useState novamente(que da um get na api)       
    }

    async function handleSubmit(e) {
        e.preventDefault(); //Evita o submit do formulario
        if (titulo.trim().length < 3) {
            setNotifyerUser({
                titleNote: "Erro no Titulo",
                textNote: `${titulo} contem menos de 3 caracteres`,
                imgIcon: "warning",
                imgAlt: "Imagem de ilustracao de erro, Cuidado!",
                showMessage: true
            })
        }
        else try {
            const promiseRetorno = await api.post(eventsTypeResource, {
                titulo:titulo
            });
            
            setTitulo("");

            //Funcao chamando API para atualizar
            updateAPI();

            setNotifyerUser({
                titleNote: "Sucesso",
                textNote: `${titulo} cadastrado com sucesso`,
                imgIcon: "success",
                imgAlt: "Imagem de ilustracai de sucessi.moca segurando um balao com simbolo de confirmacao ok",
                showMessage: true
            });
            console.log(promiseRetorno)

        } catch (error){
            setNotifyerUser({
                titleNote: "Erro na Aplicacao",
                textNote: `Nao foi possivel cadastrar ${titulo}`,
                imgIcon: "danger",
                imgAlt: "Imagem de ilustracai de erro, Warning!",
                showMessage: true
            });
        }

    }

    //Cadastra a atualizacao na api
    async function handleUpdate(e) {
        e.preventDefault();
        
        try {

            const promiseRetorno = await api.put(`${eventsTypeResource}/${idEvento}`, {titulo:titulo}) // O idEvento esta no state

            if (promiseRetorno.status === 204) {
                //Notificar usuario
                setNotifyerUser({
                    titleNote: "Sucesso",
                    textNote: `Atualizado com sucesso`,
                    imgIcon: "success",
                    imgAlt: "Imagem de ilustracai de sucessi.moca segurando um balao com simbolo de confirmacao ok",
                    showMessage: true
                });

                //Atualizar dados
                const retorno = await api.get(eventsTypeResource);
                setTipoEventos(retorno.data)

                //Sair da tela de cadastro
                editActionAbort();

            }

        } catch (error) {
            setNotifyerUser({
                titleNote: "Erro na Aplicacao",
                textNote: `Nao foi possivel atualizar ${error}`,
                imgIcon: "danger",
                imgAlt: "Imagem de ilustracai de erro, Warning!",
                showMessage: true
            });
        }
    }

    //Cancela a tela/acao de edicao (volta para o form de cadastro) {ESTA SENDO USADA NO PROPRIO COMPONENTE DO BOTAO}
    function editActionAbort() {
        setFrmEdit(false);
        setTitulo(""); //Reseta as variaveis
        setIdEvento(null); //Reseta as variaveis
    }

    //mostra o formulario de inscricao
    async function showUpdateForm(idElement){

        setFrmEdit(true);
        setIdEvento(idElement); //Preenche o id do evento para poder atualizar

        try {
            const retorno = await api.get(`${eventsTypeResource}/${idElement}`);
            setTitulo(retorno.data.titulo);
        } catch (error) {
            setNotifyerUser({
                titleNote: "Erro",
                textNote: `Erro na API`,
                imgIcon: "warning",
                imgAlt: "Imagem de ilustracai de erro. Warning",
                showMessage: true
            });
        }
    }

    //apaga o tipo de evento na api
    async function handDelete(idElement, tituloElement) {
        
        //Se nao confirma a exclusao, cancela a acao
        if (window.confirm(`Deseja apagar ${tituloElement} ?`)) {
            
            try {
                const promiseRetorno = await api.delete(`${eventsTypeResource}/${idElement}`);
                if (promiseRetorno.status == 204) {

                    //Funcao chamando API para atualizar
                    updateAPI();

                    setNotifyerUser({
                        titleNote: "Sucesso",
                        textNote: `${tituloElement} excluido com sucesso`,
                        imgIcon: "success",
                        imgAlt: "Imagem de ilustracai de sucessi.moca segurando um balao com simbolo de confirmacao ok",
                        showMessage: true
                    });
                }
    
            } catch (error){
                setNotifyerUser({
                    titleNote: "Erro",
                    textNote: `Erro na API`,
                    imgIcon: "warning",
                    imgAlt: "Imagem de ilustracai de erro. Warning",
                    showMessage: true
                });
            }

        }
        
    }


    return (
        <>

        <Notification {...notifyUser} setNotifyUser={setNotifyerUser} />
        
        {/* SPINNER - FEITO COM POSITION */}
        {showSpinner ? <Spinner/> : null}

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