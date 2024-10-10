import React from "react";
import Header from "../../Components/Header/Header";
import styles from "./HomePage.module.css"

function HomePage(){
    return(
        <>
            <Header/>
            <div className="body_container">
                <div className={styles.start_page_slider} style={{backgroundImage:'URL("Container.png")',backgroundRepeat: 'no-repeat',backgroundSize:'cover',background:'linear-gradient(rgba(255,0,0,0.1), #ebf8e1, #3f87a6)', backgroundColor:"#000",width:"100%",height:"580px",margin:"auto"}}>
                    <div className={styles.start_page_slider_item}>
                        
                    </div>
                </div>
            </div>
        </>
    )
}

export default HomePage;