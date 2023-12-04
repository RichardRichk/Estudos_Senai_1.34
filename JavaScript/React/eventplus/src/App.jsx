import Rotas from './routes/routes'
import { UserContext } from './context/AuthContext';
import { useEffect, useState } from 'react';


function App() {

  const [userData, setUserData] = useState({});

  useEffect(() => {
    const token = localStorage.getItem("token");
    setUserData( token === null ? {} : JSON.parse(token));
  }, []);

  return (
    <div className="App">

      <UserContext.Provider value={{ userData, setUserData }}>
        
        <Rotas/>

      </UserContext.Provider>

    </div>
  );
}

export default App;
