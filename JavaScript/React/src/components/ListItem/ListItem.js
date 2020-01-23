import React from "react";
import { Row, Col, Container } from "reactstrap";
import "./ListItem.css";

function ListItem(props) {
  return (
    <Container>
      <Row>
        <Col>{props.item.name}</Col>
        <Col>{props.item.quantity}</Col>
        <Col>{props.item.location}</Col>
      </Row>
    </Container>
  );
}

export default ListItem;
