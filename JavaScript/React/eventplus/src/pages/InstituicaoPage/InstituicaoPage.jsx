import React, { useState } from 'react';
import api, { institutionResource } from '../../Services/Service';

const InstituicaoPage = () => {

    //state

    const [notifyUser, setNotifyerUser] = useState();

    const [showSpinner, setShowSpinner] = useState(false); //Spinner Loading

    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao

    const [cnpj, setCnpj] = useState("");
    const [endereco, setEndereco] = useState("");
    const [nomeFantasia, setNomeFantasia] = useState("");
    const [idInstituicao, setIdInstituicao] = useState(null);

    const [instituicoes, setInstituicoes] = useState([]); //array

    useEffect(() => {

        //define a chamada em nossa api
        async function loadEventsType() {
            setShowSpinner(true)
            try {
                const retorno = await api.get(institutionResource);
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
    }, []);

    async function updateAPI() {
        const buscanstituicao = await api.get(institutionResource);

        setInstituicoes(buscanstituicao.data); //atualiza a variavel e roda o useState novamente(que da um get na api)       
    }

    async function handleSubmit(e) {
        e.preventDefault(); //Evita o submit do formulario
        if (nomeFantasia.trim().length < 3 && cnpj.trim().length <14 && endereco.trim().length <3) {
            setNotifyerUser({
                titleNote: "Erro no Titulo",
                textNote: `${nomeFantasia} contem dados a menos`,
                imgIcon: "warning",
                imgAlt: "Imagem de ilustracao de erro, Cuidado!",
                showMessage: true
            })
        }
        else try {
            const promiseRetorno = await api.post(institutionResource, {
                nomeFantasia:nomeFantasia,
                cnpj:cnpj,
                endereco:endereco
            });
            
            setNomeFantasia("");
            setCnpj("");
            setEndereco("");

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

    return (
        <>
            <Notification {...notifyUser} setNotifyUser={setNotifyerUser} />

            {/* SPINNER - FEITO COM POSITION */}
            {showSpinner ? <Spinner /> : null}

            <MainContent>
                {/* Formulario de cadastro do tipo evento */}
                <section className="cadastro-evento-section">
                    <Container>
                        <div className="cadastro-evento__box">
                            <Title titleText={"Cadastro Tipos de Eventos"} />

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
                </section>

                {/* Listagem de tipo de eventos */}
                <section className='lista-eventos-section'>
                    <Container>
                        <Title titleText={"lista tipo de eventos"} color="white" />

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

export default InstituicaoPage;