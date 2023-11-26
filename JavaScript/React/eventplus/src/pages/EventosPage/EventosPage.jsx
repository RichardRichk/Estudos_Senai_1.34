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

    const [instituicao, setInstituicao] = useState("");

    const [dataEvento, setDataEvento] = useState("");

    const [idEvento, setIdEvento] = useState(null);

    const [eventos, setEventos] = useState([]); //array

    const [idTipoEvento, setIdTipoEvento] = useState(null);
    const [tipoEvento, setTipoEvento] = useState([]);

    //const idInstituicao = 



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

    function arrayTransform(retornoApi) { //(dePara)
        let arrayOptions = [];
        retornoApi.forEach((e) => {
          arrayOptions.push({ value: e.idTipoEvento, text: e.titulo });
        });
        return arrayOptions;
      }

    async function updateAPI() {
        const buscaEventos = await api.get(eventsResource);

        setEventos(buscaEventos.data); //atualiza a variavel e roda o useState novamente(que da um get na api)       
    }

    async function handleSubmit(e) {
        e.preventDefault();

        try {
            await api.post(eventsResource, {
                nomeEvento: nome,
                dataEvento: dataEvento,
                descricao: descricao,
                idTipoEvento: idTipoEvento,
                idInstituicao: idInstituicao
            });
            setNome("");
            setDescricao("");
            setDataEvento("");
            setTipoEvento("");

            updateAPI();

            setNotifyerUser({
                titleNote: "Sucesso",
                textNote: `Evento ${nome} Cadastrado com sucesso`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustracao de sucesso. Moca segurando um balao com simbolo de confirmacao ok",
                showMessage: true,
            });
        } catch (error) {
            setNotifyerUser({
                titleNote: "Erro",
                textNote: `erro ao tentar cadastrar`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustracao de erro. Rapaz segurando um balao com simbolo",
                showMessage: true,
            });
        }
    }

    async function handleUpdate(e) {
        e.preventDefault();

        try {
            const retorno = await api.put(eventsResource + "/" + idEvento, {
                nomeEvento: nome,
                dataEvento: dataEvento,
                descricao: descricao,
                idTipoEvento: idTipoEvento,
                idInstituicao: idInstituicao
            });

            if (retorno.status === 204) {
                setNotifyerUser({
                    titleNote: "Sucesso",
                    textNote: `Evento ${nome} Atualizado com sucesso`,
                    imgIcon: "success",
                    imgAlt:
                        "Imagem de ilustracao de sucesso. Moca segurando um balao com simbolo de confirmacao ok",
                    showMessage: true,
                });

                updateAPI();

                editActionAbort();
            }
        } catch (error) {
            console.log(error);
            setNotifyerUser({
                titleNote: "Erro",
                textNote: `erro ao tentar atualizar`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustracao de erro. Rapaz segurando um balao com simbolo",
                showMessage: true,
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
                                        <Select
                                            id="TipoEvento"
                                            name={"tipoEvento"}
                                            required={"required"}
                                            value={idTipoEvento}
                                            options={arrayTransform(tipoEvento)}
                                            manipulationFunction={(e) => {
                                                setIdTipoEvento(e.target.value);
                                            }}
                                        />
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
                                        <Select
                                            id="TipoEvento"
                                            name={"tipoEvento"}
                                            required={"required"}
                                            options={arrayTransform(tipoEvento)}
                                            value={idTipoEvento}
                                            manipulationFunction={(e) => {
                                                setIdTipoEvento(e.target.value);
                                            }}
                                        />
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