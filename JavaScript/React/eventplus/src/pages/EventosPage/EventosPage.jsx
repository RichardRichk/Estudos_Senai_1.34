import React, { Fragment, useEffect, useState } from 'react';
import Title from '../../components/Titulo/Titulo';
import './EventosPage.css';
import MainContent from '../../components/Main/MainContent';
import Container from '../../components/Container/Container';
import ImageIllustrator from '../../components/ImageIllustrator/ImageIllustrator';
import { Input, Button, Select } from '../../components/FormComponents/FormComponents';
import api, {eventsResource} from "../../Services/Service.js"
import TableEv from './TableEv/TableEv';

import EventoImage from '../../assets/images/evento.svg'

const EventosPage = () => {

    const [notifyUser, setNotifyerUser] = useState();

    // const [showSpinner, setShowSpinner] = useState(false); //Spinner Loading

    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao

    const [nome, setNome] = useState("");

    const [descricao, setDescricao] = useState("");

    const [tipoEvento, setTipoEvento] = useState("");

    const [dataEvento, setDataEvento] = useState("");

    const [eventos, setEventos] = useState([ ]); //array

    useEffect(()=>{
        
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

    //MOLDA O ARRAY OPTIONS
    // function dePara(options) {
    //     const arrayOptions = [];
    //     return options.forEach(element => {
    //         arrayOptions.push({calue: element.idTipoEvento, text: element.titulo});
    //     })
    //     return arrayOptions;
    // }

    async function updateAPI() {
        const buscaEventos = await api.get(eventsResource);

        setEventos(buscaEventos.data); //atualiza a variavel e roda o useState novamente(que da um get na api)       
    }

    async function showUpdateForm(idElement){
    }

    async function handDelete(idElement) {
        
        //Se nao confirma a exclusao, cancela a acao
        if (window.confirm(`Deseja apagar ?`)) {
            
            try {
                const promiseRetorno = await api.delete(`${eventsResource}/${idElement}`);
                if (promiseRetorno.status == 204) {

                    //Funcao chamando API para atualizar
                    updateAPI();

                    setNotifyerUser({
                        titleNote: "Sucesso",
                        textNote: ` excluido com sucesso`,
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
            <MainContent>
                <Container>
                    <div className='cadastro-evento__box'>
                        <Title titleText={"Cadastro de Eventos"}/>

                        <ImageIllustrator
                            imageRender={EventoImage}
                        />

                        <form
                            className='ftipo-evento'
                        >
                        <Input
                            id={"Nome"}
                            placeholder={"Nome"}
                            name={"nome"}
                            type={"text"}
                            required={"required"}
                        />
                        <Input
                            id={"Descricao"}
                            placeholder={"Descricao"}
                            name={"descricao"}
                            type={"text"}
                            required={"required"}
                        />
                        <select name="" id="">

                        </select>
                        <Input
                            id={"DataEvento"}
                            placeholder={"dd/mm/aaaa"}
                            name={"dataEvento"}
                            type={"Date"}
                            required={"required"}
                        />

                        <Button
                            className = 'btn-cadastrar'
                            textButton="Cadastrar"
                            id="Cadastrar"
                            name="cadastrar"
                            type="submit"
                        />
                        </form>
                    </div>

                </Container>

                <section className='lista-eventos-section'>
                    <Container>

                        <Title titleText={"lista de eventos"} color="white"/>

                        <TableEv
                            dados={eventos}
                        />

                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default EventosPage;