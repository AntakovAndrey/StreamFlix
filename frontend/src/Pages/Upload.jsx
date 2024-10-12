import React, { useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";

function Upload(){
    const [file,setFile]=useState();
    const navigate = useNavigate();

    async function handleSubmit(e){
        e.preventDefault();

        const formData = new FormData();
        formData.append("file",file)

        const response = await fetch('https://localhost:7081/api/Torrent',{
            method:"POST",
            body:formData
        })
        
        if(response.ok)
        {  
            const videoUrl = await response.json();
            navigate(`/player?videoUrl=${encodeURIComponent(videoUrl)}`);
        }
    }

    function handleFileSelected(e){
        setFile(e.target.files[0]);
    }

    return(
    <>
        <form onSubmit={handleSubmit}>
            <input type="file" onChange={handleFileSelected}/>
            <button type="submit">Отправить</button>
        </form>
    </>)
}

export default Upload;