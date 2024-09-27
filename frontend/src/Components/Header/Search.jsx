import React from "react";

function Search(props){
    return(
            <input style={{display:(props.isVisible?"inline":"none")}}type="text" />
    )
}

export default Search;