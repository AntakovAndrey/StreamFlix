import React, { useEffect, useState } from "react";
import {Link} from "react-router-dom";
import navigationTabs from "./NavigationBarTabs";
import styles from "./NavigationBar.module.css"

function NavigationBar(props)
{
    useEffect(()=>{
        setSelectedTab(props.currentTab.value)
    },[])
    const [selectedTab, setSelectedTab] = useState(0)

    return(
        <>
            <Link to="/"  className={`${styles.nav_link}${selectedTab==1&&styles.nav_link_active}`}>Home</Link>
            <Link to="/discover" className={styles.nav_link}>Discover</Link>
            <Link to="/release" className={styles.nav_link}>Movie Release</Link>
            <Link to="/forum" className={styles.nav_link}>Forum</Link>
        </>
    )
}

export default NavigationBar;