import React from "react";
import NavigationBar from "./NavigationBar";
import Controls from "./Controls";
import navigationTabs from "./NavigationBarTabs";
import styles from './Header.module.css'

function Header()
{
    return(
        <>
            <div className={styles.header}>
                <div className={styles.header_inner}>
                    <div className="logo" style={{fontSize:"24px"}}>Logo</div>
                    <div className="navbar">
                        <NavigationBar currentTab={navigationTabs.home}/>
                    </div>
                    <div className="control_buttons">
                        <Controls/>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Header;