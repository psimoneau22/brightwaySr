const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
  entry: {
    app: ['regenerator-runtime', './src/index.js'],
  },
  output: {
    path: path.resolve(__dirname, '..', 'backend', 'wwwroot', 'dist'),
    filename: 'app.js',
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: "babel-loader",
          options: {
            presets: ['@babel/preset-env', '@babel/preset-react']
          }
        }
      },
      {
        test: /\.s?css$/,
        use: [
          MiniCssExtractPlugin.loader,
          "css-loader",
          "sass-loader",
        ],
      }
    ]
  },
  plugins: [
    new MiniCssExtractPlugin()
  ],
  devtool: 'eval-source-map'
};
