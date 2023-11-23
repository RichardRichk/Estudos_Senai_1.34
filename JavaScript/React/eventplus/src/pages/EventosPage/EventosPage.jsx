import React, { Fragment, useEffect, useState } from 'react';
import Title from '../../components/Titulo/Titulo';
import './EventosPage.css';
import MainContent from '../../components/Main/MainContent';
import Container from '../../components/Container/Container';
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import { Input, Button, Select } from '../../components/FormComponents/FormComponents';
import api, { eventsResource } from "../../Services/Service.js"
import TableEv from './TableEv/TableEv';
import Notification from '../../components/Notification/Notification';

import EventoImage from '../../assets/images/evento.svg'

const EventosPage = () => {

    const [notifyUser, setNotifyerUser] = useState();

    // const [showSpinner, setShowSpinner] = useState(false); //Spinner Loading

    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao

    const [nome, setNome] = useState("");

    const [descricao, setDescricao] = useState("");

    const [tipoEvento, setTipoEvento] = useState("");

    const [instituicao, setInstituicao] = useState("");

    const [dataEvento, setDataEvento] = useState("");

    const [idEvento, setIdEvento] = useState(null);

    const [eventos, setEventos] = useState([]); //array



    useEffect(() => {

        //define a chamada em nossa api
        async function loadEvents() {
            // setShowSpinner(true)
            try {
                const retorno = await api.get(eventsResource);
                setEventos(retorno.data);

                console.log(retorno.data);

            } catch (error) {
                console.log("Erro na api");
                console.log(error);
            }

            // setShowSpinner(false)
        }

        // chama a funcao/api no carregamento da pagina/componente
        loadEvents();
    }, [])

    async function updateAPI() {
        const buscaEventos = await api.get(eventsResource);

        setEventos(buscaEventos.data); //atualiza a variavel e roda o useState novamente(que da um get na api)       
    }

    async function handleSubmit(e) {
        e.preventDefault();
        if (nome.trim().length < 3) {
            setNotifyerUser({
                titleNote: "Erro no Titulo",
                textNote: `${nome} contem menos de 3 caracteres`,
                imgIcon: "warning",
                imgAlt: "Imagem de ilustracao de erro, Cuidado!",
                showMessage: true
            })
        }
        else try {
            const promiseRetorno = await api.post(eventsResource, { nome: nome, descricao: descricao, tipoEvento: tipoEvento, dataEvento: dataEvento })

            updateAPI();

            setNotifyerUser({
                titleNote: "Sucesso",
                textNote: `${nome} cadastrado com sucesso`,
                imgIcon: "success",
                imgAlt: "Imagem de ilustracai de sucessi.moca segurando um balao com simbolo de confirmacao ok",
                showMessage: true
            });
        } catch (error) {
            setNotifyerUser({
                titleNote: "Erro na Aplicacao",
                textNote: `Nao foi possivel cadastrar ${nome}`,
                imgIcon: "danger",
                imgAlt: "Imagem de ilustracai de erro, Warning!",
                showMessage: true
            });
        }
    }

    async function handleUpdate(e) {
        e.preventDefault();
        
        try {

            const promiseRetorno = await api.put(`${eventsResource}/${idEvento}`, {nome: nome, descricao: descricao, tipoEvento: tipoEvento, dataEvento: dataEvento})

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
                const retorno = await api.get(eventsResource);
                setEventos(retorno.data)

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

    function editActionAbort() {
        setFrmEdit(false);
        setNome(""); //Reseta as variaveis
        setDescricao("");
        setTipoEvento("");
        setInstituicao("");
        setDataEvento("");
        setIdEvento(null); //Reseta as variaveis
    }

    async function showUpdateForm(idElement) {
        setFrmEdit(true);

        setIdEvento(idElement);

        try {

            const retorno = await api.get(`${eventsResource}/${idElement}`);
            setNome(retorno.data.nomeEvento);
            setDescricao(retorno.data.descricao);
            setDataEvento(retorno.data.dataEvento);

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

    async function handDelete(idElement, nomeElement) {

        //Se nao confirma a exclusao, cancela a acao
        if (window.confirm(`Deseja apagar ${nomeElement} ?`)) {

            try {
                const promiseRetorno = await api.delete(`${eventsResource}/${idElement}`);
                if (promiseRetorno.status === 204) {

                    //Funcao chamando API para atualizar
                    updateAPI();

                    setNotifyerUser({
                        titleNote: "Sucesso",
                        textNote: `${nomeElement} excluido com sucesso`,
                        imgIcon: "success",
                        imgAlt: "Imagem de ilustracai de sucessi.moca segurando um balao com simbolo de confirmacao ok",
                        showMessage: true
                    });
                }

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

    }

    return (
        <>

            <Notification {...notifyUser} setNotifyUser={setNotifyerUser} />

            <MainContent>
                <Container>
                    <div className='cadastro-evento__box'>
                        <Title titleText={"Cadastro de Eventos"} />

                        <ImageIllustrator
                            imageRender={EventoImage}
                        />

                        <form
                            className='ftipo-evento'
                        >
                            {
                                !frmEdit ?
                                    <>
                                        (<p>Tela de Cadastro</p>)
                                        <Input
                                            id={"Nome"}
                                            placeholder={"Nome"}
                                            name={"nome"}
                                            type={"text"}
                                            required={"required"}
                                            value={nome}
                                            manipulationFunction={(e) => {
                                                setNome(e.target.value);
                                            }}
                                        />
                                        <Input
                                            id={"Descricao"}
                                            placeholder={"Descricao"}
                                            name={"descricao"}
                                            type={"text"}
                                            required={"required"}
                                            value={descricao}
                                            manipulationFunction={(e) => {
                                                setDescricao(e.target.value);
                                            }}
                                        />
                                        <select name="" id="">

                                        </select>
                                        <Input
                                            id={"DataEvento"}
                                            placeholder={"dd/mm/aaaa"}
                                            name={"dataEvento"}
                                            type={"Date"}
                                            required={"required"}
                                            value={dataEvento}
                                            manipulationFunction={(e) => {
                                                setDataEvento(e.target.value);
                                            }}
                                        />

                                        <Button
                                            className='btn-cadastrar'
                                            textButton="Cadastrar"
                                            id="Cadastrar"
                                            name="cadastrar"
                                            type="submit"
                                        />
                                    </>


                                    :


                                    //Edit
                                    <>
                                        (<p>Tela Edicao</p>)

                                        <Input
                                            id={"Nome"}
                                            placeholder={"Nome"}
                                            name={"nome"}
                                            type={"text"}
                                            required={"required"}
                                            value={nome}
                                            manipulationFunction={(e) => {
                                                setNome(e.target.value);
                                            }}
                                        />
                                        <Input
                                            id={"Descricao"}
                                            placeholder={"Descricao"}
                                            name={"descricao"}
                                            type={"text"}
                                            required={"required"}
                                            value={descricao}
                                            manipulationFunction={(e) => {
                                                setDescricao(e.target.value);
                                            }}
                                        />
                                        <select name="" id="">

                                        </select>
                                        <Input
                                            id={"DataEvento"}
                                            placeholder={"dd/mm/aaaa"}
                                            name={"dataEvento"}
                                            type={"Date"}
                                            required={"required"}
                                            value={dataEvento}
                                            manipulationFunction={(e) => {
                                                setDataEvento(e.target.value);
                                            }}
                                        />
                                        <div className='buttons-editbox'>
                                            <Button
                                                textButton="Atualizar"
                                                id="Atualizar"
                                                name="Atualizar"
                                                type="submit"
                                                manipulationFunction={handleUpdate}
                                                additionalClass="button-component--midle"
                                            />

                                            <Button
                                                textButton="Cancelar"
                                                id="Cancelar"
                                                name="Cancelar"
                                                type="button"
                                                manipulationFunction={editActionAbort}
                                                additionalClass="button-component--midle"
                                            />
                                        </div>
                                    </>
                            }
                        </form>
                    </div>

                </Container>

                <section className='lista-eventos-section'>
                    <Container>

                        <Title titleText={"lista de eventos"} color="white" />

                        <TableEv
                            dados={eventos}
                            fnDelete={handDelete}
                            fnUpdate={showUpdateForm}
                        />

                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default EventosPage;