import React from "react";
import {BrowserRouter,Route,Routes} from 'react-router-dom'
import Upload from "./Pages/Upload"
import Player from "./Pages/Player"

function App() {  
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Upload/>}/>
          <Route path="/player" element={<Player/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;