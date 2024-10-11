import React, { useState } from "react";

function Upload(){
    const [file,setFile]=useState();

    async function showFile(e){
        e.preventDefault();
    }

    function handleFileSelected(e){
        setFile(e.target.files[0]);
    }

    return(
    <>
        <form onSubmit={showFile}>
            <input type="file" onChange={handleFileSelected}/>
            <button type="submit">Отправить</button>
        </form>
    </>)
}

export default Upload;