import React, { Fragment, useEffect, useState } from 'react';
import Title from '../../components/Titulo/Titulo';
import './EventosPage.css';
import MainContent from '../../components/Main/MainContent';
import Container from '../../components/Container/Container';
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import { Input, Button, Select } from '../../components/FormComponents/FormComponents';
import api, { eventsResource, eventsTypeResource } from "../../Services/Service.js"
import TableEv from './TableEv/TableEv';
import Notification from '../../components/Notification/Notification';

import EventoImage from '../../assets/images/evento.svg'
import { dateToView } from '../../Utils/stringFunctions.js';

const EventosPage = () => {

    const [notifyUser, setNotifyerUser] = useState();

    // const [showSpinner, setShowSpinner] = useState(false); //Spinner Loading

    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao

    const [nome, setNome] = useState();

    const [descricao, setDescricao] = useState();

    const [dataEvento, setDataEvento] = useState();

    const [idEvento, setIdEvento] = useState();

    const [eventos, setEventos] = useState([]); //array

    const [idTipoEvento, setIdTipoEvento] = useState();
    const [tipoEvento, setTipoEvento] = useState([]);

    //const idInstituicao = 'e555ff8f-ea4e-4c2b-891d-29ecbbdbc38c';
    const idInstituicao = '54715823-86f1-40e6-ae06-79cd252838eb';



    useEffect(() => {

        //define a chamada em nossa api
        async function loadEvents() {
            // setShowSpinner(true)
            try {
                const retorno = await api.get(eventsResource);
                setEventos(retorno.data);

                const request = await (await api.get(eventsTypeResource)).data;
                setTipoEvento(request);

                //Retirar
                console.log("TESTE");
                console.log(request);

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
        if (nome.trim().length < 5) {

            setNotifyerUser({
                titleNote: "Titulo deve Possuir mais de 3 Caracteres",
                textNote: `Nao foi possivel Cadastrar o ${nome}`,
                imgIcon: "danger",
                imgAlt: "Imagem de ilustracai de erro, Warning!",
                showMessage: true
            })
        } else try {

            const objetoEvento = {
                "dataEvento": dataEvento,
                "nomeEvento": nome,
                "descricao": descricao,
                "idTipoEvento": idTipoEvento,
                "idInstituicao": idInstituicao
            }

            await api.post(eventsResource, {

                "dataEvento": dataEvento,
                "nomeEvento": nome,
                "descricao": descricao,
                "idTipoEvento": idTipoEvento,
                "idInstituicao": idInstituicao
            });
            setNome("");
            setDescricao("");
            setDataEvento("");

            setNotifyerUser({
                titleNote: "Sucesso",
                textNote: `Evento ${nome} Cadastrado com sucesso`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustracao de sucesso. Moca segurando um balao com simbolo de confirmacao ok",
                showMessage: true,
            });

            //Retirar
            console.log(idTipoEvento);
            console.log(objetoEvento);

            updateAPI();

        } catch (error) {
            setNotifyerUser({
                titleNote: "Erro",
                textNote: `erro ao tentar cadastrar`,
                imgIcon: "danger",
                imgAlt:
                    "Imagem de ilustracao de erro. Rapaz segurando um balao com simbolo",
                showMessage: true,
            });
            console.log(idTipoEvento);
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
        setIdEvento("");
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
            setDataEvento(dateToView(retorno.data.dataEvento));
            setIdTipoEvento(retorno.data.idTipoEvento);

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
                            className='ftipo-evento' onSubmit={frmEdit ? handleUpdate : handleSubmit}
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
                                            id={"TipoEvento"}
                                            name={"tipo evento"}
                                            options={tipoEvento}
                                            required={"required"}
                                            defaultValue={idTipoEvento}
                                            manipulationFunction={e => {
                                                setIdTipoEvento(e.target.value)
                                            }}
                                        />
                                        <Input
                                            id={"DataEvento"}
                                            placeholder={"dd/mm/aaaa"}
                                            name={"dataEvento"}
                                            type={"date"}
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
                                            type={"submit"}
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
                                            id={"TipoEvento"}
                                            name={"tipo evento"}
                                            options={tipoEvento}
                                            required={"required"}
                                            defaultValue={idTipoEvento}
                                            manipulationFunction={e => {
                                                setIdTipoEvento(e.target.value)
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