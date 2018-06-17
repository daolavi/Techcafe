import api from './backend-api'

export default {
  login (username, password, callback) {
    let data = {
      username : username,
      password : password,
    }
    api.login('token', data).then((res) => {
      const token = res.data.token;
      let user = {
        username : username,
      };
      Store.dispatch('user/updateUser', {user, token});
      if (callback){
        callback(true,null);
      }
      this.onChange(true)
    }, (err) => {
      if (callback){
        callback(false, err);
      }
      this.onChange(false);
    })
  },
  getToken () {
    return Store.state.user.token;
  },
  logout (callback) {
    Store.dispatch('user/logout');
    if (callback) {
      callback(false);
    }
    this.onChange(false);
  },
  loggedIn () {
    return !!Store.state.user.token;
  },
  onChange () {}
}
