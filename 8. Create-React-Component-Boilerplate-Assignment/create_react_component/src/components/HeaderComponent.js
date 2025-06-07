import React from "react";
import LogoComponent from "./LogoComponent";
import ViewTitleComponent from "./ViewTitleComponent";

class HeaderComponent extends React.Component {
    render() {
        return (
            <div>
                <h2> I am Header Component!!</h2>
                <LogoComponent></LogoComponent>
                <ViewTitleComponent></ViewTitleComponent>
            </div>
        );
    }
}
export default HeaderComponent;