/**
 *  Modulo para trabalhar com apis. Disponibiliza as rotas da api bem como o servico com a biblioteca axios
 */
import axios from "axios";


/**
 *  Rota para o recurso eventos
 */
export const eventsResource = '/Evento'

/**
 *  Rota para o recurso proximos eventos
 */
export const nextEventResource = '/Evento/ListarProximos'

/**
 *  Rota para o recurso tipos eventos
 */
export const eventsTypeResource = '/TiposEvento'

/**
 * Rota para recurso intituicao
 */
export const institutionResource = '/Instituicao'

/**
 * Rota para recurso Login
 */
export const loginResource = '/login'

/**
 * Rota para recurso Login
 */
export const myEventosResource = '/PresencasEvento/ListarMinhas'

//Mudar apiPort e localApiUri
const apiPort = '7118';
const localApiUri = `https://localhost:${apiPort}/api`;
const externalApiUri = null;

const api = axios.create({
    baseURL:localApiUri
});

export default api;