import axios from 'axios'

const baseUrl = BACKEND_API_URL;

const instance = axios.create({
  baseURL: baseUrl,
  timeout: false,
  params: {}
});

instance.interceptors.request.use(function (config) {
  const token = Store.state.user;
  if (token) {
    config.headers.common['Authorization'] = 'Bearer ' + token;
    config.headers.common['Access-Control-Allow-Origin'] = '*';
  }
  return config;
}, function (error) {
  return Promise.reject(error);
})

instance.interceptors.response.use(
  (response) => response, 
  (error) => { return Promise.reject(error); }
);

export default {
  getData (action) {
    let url = `${baseUrl}/${action}`;
    return instance.get(url);
  },
  postData (action, data) {
    let url = `${baseUrl}/${action}`;
    return instance.post(url, data);
  },
  putData (action, data) {
    let url = `${baseUrl}/${action}`;
    return instance.put(url, data);
  },
  deleteData (action) {
    let url = `${baseUrl}/${action}`;
    return instance.delete(url);
  },
  login (action, data) {
    let url = `${baseUrl}/${action}`;
    return instance.post(url, data);
  }
}
