const webpack = require('webpack');
var path = require('path');
const MiniCssExtractPlugin  = require('mini-css-extract-plugin');

module.exports = [
    {
        entry: {
            'bundle': './ClientApp/app.js',
        },

        output: {
            path: path.resolve('./wwwroot/dist'),
            filename: '[name].js'
        },

        resolve: {
            extensions: ['.js', '.json']
        },

        module: {
            rules: [
                {
                    test: /\.js/, use: [{
                        loader: 'babel-loader'
                    }], exclude: /node_modules/
                },
                {
                    test: /\.css$/,
                    use: [{
                        loader: MiniCssExtractPlugin.loader,
                        options: {
                            // you can specify a publicPath here
                            // by default it uses publicPath in webpackOptions.output
                            publicPath: '/wwwroot/dist',
                        },
                    },
                        'css-loader',
                    ]
                }
            ]
        },

        plugins: [
            new MiniCssExtractPlugin({
                // Options similar to the same options in webpackOptions.output
                // both options are optional
                filename: '[name].css',
                chunkFilename: '[id].css',
            }),
        ],
    }
];