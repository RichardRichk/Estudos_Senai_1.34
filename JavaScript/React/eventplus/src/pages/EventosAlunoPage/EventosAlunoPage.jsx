import React, { useContext, useEffect, useState } from "react";

import MainContent from "../../components/Main/MainContent";
import Title from "../../components/Titulo/Titulo";
import Table from "./TableEva/TableEva";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal.jsx";
import api, { eventsResource, myEventosResource, presencesEventResource, commentsResource } from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";


const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);


  
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);
  const [comentario, setComentario] = useState("");
  
  const [idComentario, setIdComentario] = useState();

  useEffect(() => {
    
    loadEvents();
  }, [tipoEvento, userData.userId]); //userData.userId


  async function loadEvents(){

    // setEventos([]);

    if (tipoEvento === "1") {//Todos os eventos

      try {
        //Listar os eventos (Evento)
        const todosEventos = await api.get(eventsResource);

        const meusEventos = await api.get(`${myEventosResource}/${userData.userId}`);

        const eventosMarcados = verificaPresenca(todosEventos.data, meusEventos.data);

        setEventos(eventosMarcados);

      } catch (error) {
        console.log("Erro na api");
        console.log(error);
      }
      
    } else if (tipoEvento === "2"){

      //Listar neys evebtis(PresencasEventos)
      //Retorna um formato diferente de array

      try {

        const retornoEventos = await api.get(`${myEventosResource}/${userData.userId}`);

        const arrEventos = []; //Array vazio

        retornoEventos.data.forEach(e => {

          arrEventos.push({...e.evento, situacao : e.situacao, idPresencaEvento: e.idPresencaEvento});

        });

        setEventos(arrEventos);

      } catch (error) {
        
        console.log("Erro na api");
        console.log(error);

      }
    } else {
      setEventos ([]);
    }
  }


  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  const loadMyComentary = async (idUsuario, idEvento) => {

    const retorno = await api.get(`${commentsResource}/BuscarPorIdUsuario?idUsuario=${idUsuario}&idEvento=${idEvento}`);

    setComentario(retorno.data.descricao);
    setIdComentario(retorno.data.idComentarioEvento)
  }

  const verificaPresenca = (arrayAllEvents, eventsUser) => {
    for (let x = 0; x < arrayAllEvents.length; x++) { //Para cada evento cadastrado
      for (let i = 0; i < eventsUser.length; i++) { //procurar a correspondencia

        if (arrayAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
          arrayAllEvents [x].situacao = true;
          arrayAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;
          break; //paro de procurar para o evento principal atual
        }
        
      }
    }
    //Retorna todos os eventos marcados com a presenca do usuario
    return arrayAllEvents;
  }

  const showHideModal = (idEvento) => {
    setShowModal(showModal ? false : true);
    setUserData({...userData, idEvento: idEvento})
  };

  const newCommentary = async (descricao, idUsuario, idEvento) => {
    try {

      const promise = await api.post(commentsResource, {
        descricao: descricao,
        exibe: true,
        idUsuario: idUsuario,
        idEvento: idEvento,
      });

      if (promise.status === 200) {
        loadMyComentary(idUsuario, idEvento);
      };

    } catch (error) {
      alert("Erro")
    }
  }

  // remove o comentário
  async function commentaryRemove() {

    try {
        const request = await api.delete(`${commentsResource}/${idComentario}`)

        setComentario("Comentário Deletado!")

    } catch (error) {

    }

};

  async function handleConnect(eventId, whatTheFunction, presencaId = null) {
    if (whatTheFunction === "connect") {

      try {//CONNECT
        const retorno = await api.post(presencesEventResource, {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: eventId
        })
        if (retorno.status == 201) {
                     
          const todosEventos = api.get(eventsResource);
          setEventos(todosEventos.data);

          alert("Conectar ao evento: " + eventId);

        }
      } catch (error){
        
      }

    } else {

      try {
        const unconnect = await api.delete(`${presencesEventResource}/${presencaId}`);

        if (unconnect.status === 204) {
          alert("Desconectar do evento: " + eventId);

          const todosEventos = await api.get(eventsResource);
          setEventos(todosEventos.data);
        }

      } catch (error) {
        
      }
    }

    loadEvents();
  }
  return (
    <>

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            options={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={showHideModal}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
        userId={userData.userId}
          fnPost={newCommentary}
          fnGet={loadMyComentary}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
          comentaryText={comentario}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
