import React, { Component } from "react";
import { View, Button, Text, Image, StyleSheet, FlatList } from "react-native";

import api from "../services/api";

class Main extends Component {
  static navigationOptions = {
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../assets/img/calendar.png")}
        style={{ width: 25, height: 25, tintColor: "#FFF" }}
      />
    )
  };

  constructor(props) {
    super(props);
    this.state = { lista: [] };
  }

  componentDidMount() {
    this.loadEventos();
  }

  loadEventos = async () => {
    const response = await api.get("/eventos");

    const docs = response.data;

    this.setState({ listaEventos: docs });
  };

  renderItem = ({ item }) => (
    <View style={styles.eventoLine}>
      <View style={styles.eventoContainer}>
        <Text style={styles.eventoTitle}>{item.titulo}</Text>
        <Text style={styles.eventoDate}>{item.dataEvento}</Text>
      </View>
      <View style={styles.eventoImg}>
        <Image
          source={require("../assets/img/view.png")}
          style={styles.eventoImgIcon}
        />
      </View>
    </View>
  );

  render() {
    return (
      <View style={styles.main}>
        <View style={styles.mainView}>
          <View style={styles.mainViewRow}>
            <Image
              source={require("../assets/img/calendar.png")}
              style={styles.mainViewRowImg}
            />
            <Text
              style={styles.mainViewRowText}
            >
              {"Eventos".toUpperCase()}
            </Text>
          </View>
          <View
            style={styles.mainViewRowImgIcon}
          />
        </View>
        <View style={styles.container}>
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
  main: { 
    flex: 1, 
    backgroundColor: "#F1F1F1" 
  },
  mainViewRow: { 
    flexDirection: "row" 
  },
  mainView: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center"
  },
  mainViewRowImg: {
    width: 22,
    height: 22,
    tintColor: "#cccccc",
    marginRight: -9,
    marginTop: -9
  },
  mainViewRowText: {
    fontSize: 16,
    letterSpacing: 5,
    color: "#999999",
    fontFamily: "OpenSans-Regular"
  },
  mainViewRowImgIcon : {
    width: 170,
    paddingTop: 10,
    borderBottomColor: "gray",
    borderBottomWidth: 0.9
  },
  eventoLine: {
    flexDirection: "row",
    borderBottomWidth: 0.9,
    borderBottomColor: "gray"
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
  eventoImg: {
    justifyContent: "center",
    alignContent: "center",
    alignItems: "center"
  },
  eventoImgIcon: {
    width: 22,
    height: 22,
    tintColor: "#B727FF"
  },
  eventoDate: {
    fontSize: 10,
    color: "#999",
    lineHeight: 24
  }
});

export default Main;
