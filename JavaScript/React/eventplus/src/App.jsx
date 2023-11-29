import Rotas from './routes'
import { UserContext } from './context/AuthContext';
import { useState } from 'react';


function App() {

  const [userData, setUserData] = useState({})

  return (
    <div className="App">

      <UserContext.Provider value={{ userData, setUserData }}>
        
        <Rotas/>

      </UserContext.Provider>

    </div>
  );
}

export default App;
