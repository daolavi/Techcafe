<template>
    <v-container fill-height justify-center align-center>
      <v-flex xs12 sm5 md4 lg3>
        <v-card class="mt-0 pt-0">
          <v-card-title class="blue darken-1">
            <h4 style="color:white">Login</h4>
          </v-card-title>
          <v-card-text>
            <form @submit.prevent="login">
                <v-layout row wrap>
                  <v-flex xs12 md4 >
                    <v-subheader>Username</v-subheader>
                  </v-flex>
                  <v-flex xs12 md8>
                    <v-text-field class="input-group--focused" name="username" v-model="username" label="username" value="Input text"></v-text-field>
                  </v-flex>
                </v-layout>
                <v-layout row wrap>
                  <v-flex xs12 md4>
                    <v-subheader>Password</v-subheader>
                  </v-flex>
                  <v-flex xs12 md8>
                    <v-text-field class="input-group--focused" name="password" type="password" v-model="password" label="password" value="Input text"></v-text-field>
                  </v-flex>
                </v-layout>
                <v-layout row justify-center align-center>
                  <v-btn type="submit" v-if="!isLogging">Login</v-btn>
                  <v-progress-circular v-if="isLogging" :size="48" indeterminate color="primary"></v-progress-circular>
                </v-layout>
                <v-snackbar v-if="error" :timeout="3000" :top="true" :multi-line="true" v-model="error">
                  {{ text }}
                  <v-btn class="pink--text" flat @click.native="error = false">Close</v-btn>
                </v-snackbar>
            </form>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-container>
</template>
<style lang="stylus">
  @import '../stylus/main'
</style>
<script>
import auth from '../utils/auth'

export default {
  data () {
    return {
      username: 'techcafe',
      password: 'techcafe',
      error: false,
      text: '',
      isLogging: false
    }
  },
  methods: {
    login () {
      this.isLogging = true;
      auth.login(this.username, this.password, (loggedIn, err) => {
        if (err) {
          console.log(err);
          this.error = true;
          this.text = 'Wrong username or password.';
          this.isLogging = false;
        } else {
          console.log(this.$route);
          this.$router.push(this.$route.query.redirect || '/');
        }
      })
    }
  }
}
</script>