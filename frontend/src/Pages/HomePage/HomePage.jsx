import React from "react";
import Header from "../../Components/Header/Header";
import styles from "./HomePage.module.css"

function HomePage(){
    return(
        <>
            <Header/>
            <div className="body_container">
                <div className={styles.start_page_slider} style={{backgroundColor:"#000",width:"100%",height:"580px",margin:"auto"}}>
                    <div className={styles.start_page_slider_item}>
                        <img width="100%" src="Container.png" />
                    </div>
                </div>
            </div>
        </>
    )
}

export default HomePage;