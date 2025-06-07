import React from "react";
import BodyLeftComponent from "./BodyLeftComponent";
import BodyRightComponent from "./BodyRightComponent";

class BodyComponent extends React.Component {
    render() {
        return (
            <div>
                <h2> I am Body Component!!</h2>
                <BodyLeftComponent></BodyLeftComponent>
                <BodyRightComponent></BodyRightComponent>
            </div>
        );
    }
}
export default BodyComponent;