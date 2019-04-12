import React, { Component } from "react";
import { View, Button, Text, Image, StyleSheet, FlatList } from "react-native";

import api from "../services/api";

class Main extends Component {
  static navigationOptions = {
    // tabBarLabel: "Home",
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../assets/img/calendar.png")}
        style={{ width: 25, height: 25, tintColor: "#FFF" }}
      />
    )
  };

  state = {
    listaEventos: []
  };

  componentDidMount() {
    this.loadEventos();
  }

  loadEventos = async () => {
    const response = await api.get("/eventos");

    const docs = response.data;

    this.setState({ listaEventos: docs });

    console.log(docs);
  };

  renderItem = ({ item }) => (
    <View
      style={{
        flexDirection: "row",
        borderBottomWidth: 0.9,
        borderBottomColor: "gray"
        // marginBottom: 10
      }}
    >
      <View style={styles.eventoContainer}>
        <Text style={styles.eventoTitle}>{item.titulo}</Text>
        <Text style={styles.eventoDate}>{item.dataEvento}</Text>
      </View>
      <View
        style={{
          justifyContent: "center",
          alignContent: "center",
          alignItems: "center"
        }}
      >
        <Image
          source={require("../assets/img/view.png")}
          style={{ width: 22, height: 22, tintColor: "#B727FF" }}
        />
      </View>
    </View>
  );

  render() {
    return (
      <View style={{ flex: 1, backgroundColor: "#F1F1F1" }}>
        <View
          style={{
            flex: 1,
            // backgroundColor: "powderblue",
            justifyContent: "center",
            alignItems: "center"
          }}
        >
          <View style={{ flexDirection: "row" }}>
            {/* <View> */}
            <Image
              source={require("../assets/img/calendar.png")}
              style={{
                width: 22,
                height: 22,
                tintColor: "#cccccc",
                marginRight: -9,
                marginTop: -9
              }}
            />
            {/* </View> */}
            <Text
              style={{
                fontSize: 16,
                letterSpacing: 5,
                color: "#999999",
                fontFamily: "OpenSans-Regular"
              }}
            >
              {"Eventos".toUpperCase()}
            </Text>
          </View>
          <View
            style={{
              width: 170,
              paddingTop: 10,
              borderBottomColor: "gray",
              borderBottomWidth: 0.9
            }}
          />
        </View>
        <View
          // style={{
          //   flex: 4
          //   // backgroundColor: "skyblue"
          // }}
          style={styles.container}
        >
          {/* {this.state.listaEventos.map(evento => (
            <Text key={evento.id}>{evento.titulo}</Text>
          ))} */}
          <FlatList
            contentContainerStyle={styles.list}
            data={this.state.listaEventos}
            keyExtractor={item => item.id}
            renderItem={this.renderItem}
          />
        </View>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    // backgroundColor: "#fafafa",
    flex: 4
  },
  list: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50
  },
  eventoContainer: {
    flex: 7,
    marginTop: 5
  },
  eventoTitle: {
    fontSize: 14,
    color: "#333",
    fontFamily: "OpenSans-Light"
  },
  eventoDate: {
    fontSize: 10,
    color: "#999",
    lineHeight: 24
  }
});

export default Main;
