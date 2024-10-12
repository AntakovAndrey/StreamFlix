import React from "react";
import {useLocation} from 'react-router-dom'

function Player(){
    const location = useLocation();
    const params = new URLSearchParams(location.search)
    const videoUrl = params.get("videoUrl")
    console.log(videoUrl)
    return(
        <>
            <h2>Воспроизведение видео</h2>
            <video controls autoPlay width="80%">
                <source src={(videoUrl)} type="video/mp4" />
                Ваш браузер не поддерживает видео.
            </video>
        </>
    )
}

export default Player;