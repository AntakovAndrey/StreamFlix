import React, { useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";

function Upload(){
    const [file,setFile]=useState();
    const navigate = useNavigate();

    async function handleSubmit(e){
        e.preventDefault();

        const formData = new FormData();
        formData.append("file",file)

        const response = await fetch('url',{
            method:"POST",
            body:formData
        })

        if(response.ok)
        {
            navigate(`/player?videoUrl=${response.json().then(res=>res.videoURL)}`);
        }
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